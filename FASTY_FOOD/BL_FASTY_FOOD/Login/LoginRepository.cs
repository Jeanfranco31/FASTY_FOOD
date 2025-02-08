using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BL_FASTY_FOOD.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE_FASTY_FOOD.Helper;

namespace BL_FASTY_FOOD.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string _connection;
        public LoginRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString(DbUtilities.connectionName)!;
        }

        public async Task<Response> ValidateLogin(LoginDto login)
        {
            Response response = new();
            try
            {
                using (SqlConnection conn = new(_connection))
                {
                    SqlCommand cmd = new(ProcedureName.SP_ValidateLogin, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Parameter.paramUsername, SqlDbType.VarChar) { Value = login.Username });
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (existUsername(reader))
                    {
                        if (validPassword(reader, login))
                        {
                            //retornar token aqui, cambiar esta parte

                            response.Data = login;
                            response.Message = MessageResponse.CorrectAuthentication;
                            response.code = CodeStatus.OK;
                        }
                        else
                        {
                            response.Message = MessageResponse.DifferentPassword;
                            response.code = CodeStatus.ERROR;
                        }
                    }
                    else
                    {
                        response.Message = MessageResponse.UsernameNotExist;
                        response.code = CodeStatus.ERROR;
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        private bool existUsername(SqlDataReader reader) { 
            bool exist = false;
            LoginDto login = null!;

            if (reader.Read()) { 
                string pass = reader.GetString(1);
                if(pass != null || pass != string.Empty)
                {
                    exist = true;
                }
            }
            return exist;
        }

        private bool validPassword(SqlDataReader reader, LoginDto login) {
            bool samePassword = false;

            if (reader.Read())
            {
                string pass = reader.GetString(1);
                string passRevice = Helper.Encrypt(login.Password);
                if(pass.Equals(passRevice))
                {
                    samePassword = true;
                }
            }
            return samePassword;
        }

    }
}
