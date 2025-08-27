using BE_FASTY_FOOD.DefaultResponse;
using BL_FASTY_FOOD.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using BE_FASTY_FOOD.Dto;

namespace BL_FASTY_FOOD.Rol
{
    public class RolRepository: IRolRepository
    {
        private readonly string _connection;
        public RolRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString(DbUtilities.connectionName)!;
        }

        public async Task<Response> CreateRol(RolDto rol)
        {
            Response response = new();
            RolDto rolData = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    bool exist = validateExistRol(rol.Rolname);
                    if (!exist)
                    {
                        SqlCommand cmd = new(ProcedureName.SP_InsertNewRol, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter(Parameter.paramRolName, SqlDbType.VarChar) { Value = rol.Rolname});
                        cmd.Parameters.Add(new SqlParameter(Parameter.paramDateRegister, SqlDbType.DateTime) { Value = rol.DateRegister });
                        cmd.Parameters.Add(new SqlParameter(Parameter.paramStatusRol, SqlDbType.Bit) { Value = rol.StatusRol });
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        if(await reader.ReadAsync())
                        {
                            rolData = new RolDto
                            {
                                Id = reader.GetInt32(0),
                                Rolname = reader.GetString(1),
                                DateRegister = Convert.ToDateTime(reader.GetString(2)),
                                StatusRol = reader.GetBoolean(3)
                            };
                            response.Data = rolData;
                            response.code = CodeStatus.OK;
                            response.Message = MessageResponse.RolCorrectInsert;
                        }
                    }
                    else
                    {
                        response.Message = MessageResponse.RolExist;
                        response.code = CodeStatus.ERROR;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> GetAllRols()
        {
            Response response = new();
            List<RolDto> list = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_GetRols,conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while(await reader.ReadAsync())
                    {
                        RolDto rol = new RolDto
                        {
                            Id = reader.GetInt32(0),
                            Rolname = reader.GetString(1),
                            DateRegister = Convert.ToDateTime(reader.GetString(2)),
                            StatusRol = reader.GetBoolean(3)
                        };
                        list.Add(rol);
                    }
                    response.Data = list;
                    response.code = CodeStatus.OK;
                    response.Message = MessageResponse.DefaultMessage;
                }
                catch (Exception ex)
                {
                    response.code = CodeStatus.ERROR;
                    response.Message = MessageResponse.DefaultErrorMessage;
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> GetRolByStatusOrProfileName(bool? status, string profile)
        {
            Response response = new();
            List<RolDto> list = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_GetRolsByStatus, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramStatusRol, SqlDbType.Bit) { Value = status});
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramRolName, SqlDbType.VarChar) { Value = profile });

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while(await reader.ReadAsync())
                    {
                        RolDto rolDto = new RolDto
                        {
                            Id = reader.GetInt32(0),
                            Rolname = reader.GetString(1)
                        };
                        list.Add(rolDto);
                    }
                    response.Data = list;
                    response.Message = MessageResponse.DefaultMessage;
                    response.code = CodeStatus.OK;

                }
                catch (Exception ex)
                {
                    response.Message = MessageResponse.DefaultErrorMessage;
                    response.code = CodeStatus.ERROR;
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        private bool validateExistRol(string rolName) {
            bool exist = false;
            int rol = 0;

            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new(ProcedureName.SP_ValidateRolExist, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(Parameter.paramRolName,SqlDbType.VarChar) { Value = rolName });
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) {
                        rol = reader.GetInt32(0);
                    }

                    if (rol > 0) {
                        return true;
                    }

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return exist;
        }

    }
}
