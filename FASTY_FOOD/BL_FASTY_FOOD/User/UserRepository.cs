using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BL_FASTY_FOOD.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE_FASTY_FOOD.Helper;
using BE_FASTY_FOOD.Models;

namespace BL_FASTY_FOOD.User
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connection = DbUtilities.connectionName;
        Response response = new();

        public async Task<Response> CreateNewUser(UserDto user)
        {
            UserDto userDto = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_CreateNewUser, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramIdentification, SqlDbType.VarChar) { Value = user.Identification});
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramFullName, SqlDbType.VarChar) { Value = user.FullName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramUserName, SqlDbType.VarChar) { Value = user.UserName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramEmail, SqlDbType.VarChar) { Value = user.Email });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramAddress, SqlDbType.VarChar) { Value = user.AddressDirection });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramCompanyName, SqlDbType.VarChar) { Value = user.CompanyName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramRolName, SqlDbType.VarChar) { Value = user.RolName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramStatusUser, SqlDbType.VarChar) { Value = user.Status });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramPass, SqlDbType.VarChar) { Value = Helper.Encrypt(user.Identification)});

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    
                    if(await reader.ReadAsync())
                    {
                        userDto = new UserDto { 
                            Id = reader.GetInt32(0),
                            Identification = reader.GetString(1),
                            FullName = reader.GetString(2),
                            Email = reader.GetString(3),
                            UserName = reader.GetString(4),
                            AddressDirection = reader.GetString(5),
                            CompanyName = reader.GetString(6),
                            RolName = reader.GetString(7),
                            Status = reader.GetBoolean(8)
                        };
                    }
                    response.Data = userDto;
                    response.Message = MessageResponse.UserCreate;
                    response.code = CodeStatus.OK;

                }
                catch
                {
                    response.Message = MessageResponse.ErrorCreateUser;
                    response.code = CodeStatus.ERROR;
                }finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> FoundByCompanyName(string companyName)
        {
            UserDto userDto = null!;
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_FoundUserByCompanyName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramCompanyName, SqlDbType.VarChar) { Value = companyName });
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while(await reader.ReadAsync())
                    {
                        userDto = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Identification = reader.GetString(1),
                            FullName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            CompanyName = reader.GetString(4),
                            Status = reader.GetBoolean(5)
                        };
                    }
                    response.Data = userDto;
                    response.Message = MessageResponse.DefaultMessage;
                    response.code = CodeStatus.OK;
                }
                catch
                {
                    response.Message = MessageResponse.NameCompanyNotExist;
                    response.code = CodeStatus.ERROR;
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> FoundByIdentification(string identification)
        {
            UserDto userDto = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_FoundByIdentification, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramIdentification, SqlDbType.VarChar) { Value = identification});
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        userDto = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Identification = reader.GetString(1),
                            FullName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            CompanyName = reader.GetString(4),
                            Status = reader.GetBoolean(5)
                        };
                    }
                    response.Data = userDto;
                    response.Message = MessageResponse.DefaultMessage;
                    response.code = CodeStatus.OK;
                }
                catch
                {
                    response.Message = MessageResponse.IdentificationNotFound;
                    response.code = CodeStatus.ERROR;
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> GetAllUsers()
        {
            List<UserDto> list = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_GetAllUsers, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        UserDto userDto = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Identification = reader.GetString(1),
                            FullName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            CompanyName = reader.GetString(4),
                            Status = reader.GetBoolean(5)
                        };
                        list.Add(userDto);
                    }
                    response.Data = list;
                    response.Message = MessageResponse.DefaultMessage;
                    response.code = CodeStatus.OK;
                }
                catch
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

        public async Task<Response> UpdateUser(UserDto user)
        {
            UserDto userDto = new();
            using (SqlConnection conn = new(_connection))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new(ProcedureName.SP_UpdateUser, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramId, SqlDbType.Int) { Value = user.Id });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramIdentification, SqlDbType.VarChar) { Value = user.Identification });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramFullName, SqlDbType.VarChar) { Value = user.FullName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramEmail, SqlDbType.VarChar) { Value = user.Email });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramAddress, SqlDbType.VarChar) { Value = user.AddressDirection });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramUserName, SqlDbType.VarChar) { Value = user.UserName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramCompanyName, SqlDbType.VarChar) { Value = user.CompanyName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramRolName, SqlDbType.VarChar) { Value = user.RolName });
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramStatusUser, SqlDbType.Bit) { Value = user.Status });

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        userDto = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Identification = reader.GetString(1),
                            FullName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            CompanyName = reader.GetString(4),
                            Status = reader.GetBoolean(5)
                        };
                    }
                    response.Data = userDto;
                    response.Message = MessageResponse.DefaultMessage;
                    response.code = CodeStatus.OK;
                }
                catch
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
    }
}
