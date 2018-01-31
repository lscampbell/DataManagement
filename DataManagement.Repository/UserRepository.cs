using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;

namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool AddUser(User user)
        {
            try 
            {  
                DynamicParameters parameters = new DynamicParameters();  
                parameters.Add("@UserName", user.UserName);  
                parameters.Add("@UserMobile", user.UserMobile);  
                parameters.Add("@UserEmail", user.UserEmail);  
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);  
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);  
                parameters.Add("@TwitterUrl", user.TwitterUrl);  
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);  
                SqlMapper.Execute(con, "AddUser", parameters, commandType: StoredProcedure);

                return true;  

            } 
            catch (Exception) 
            {  
                throw;  
            }
        }

        public bool DeleteUser(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();  
            parameters.Add("@UserId", userId);  
            SqlMapper.Execute(con, "DeleteUser", parameters, commandType: StoredProcedure);  

            return true;  
        }

        public IList<User> GetAllUser()
        {
            IList < User > customerList = SqlMapper.Query < User > (con, "GetAllUsers", commandType: StoredProcedure).ToList(); 

            return customerList; 
        }

        public User GetUserById(int userId)
        {
            try 
            {  
                DynamicParameters parameters = new DynamicParameters();  
                parameters.Add("@CustomerID", userId);  

                return SqlMapper.Query < User > ((SqlConnection) con, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();  
            } 
            catch (Exception) 
            {  
                throw;  
            } 
        }

        public bool UpdateUser(User user)
        {
            try 
            {  
                DynamicParameters parameters = new DynamicParameters();  
                parameters.Add("@UserId", user.UserId);  
                parameters.Add("@UserName", user.UserName);  
                parameters.Add("@UserMobile", user.UserMobile);  
                parameters.Add("@UserEmail", user.UserEmail);  
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);  
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);  
                parameters.Add("@TwitterUrl", user.TwitterUrl);  
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);  
                SqlMapper.Execute(con, "UpdateUser", parameters, commandType: StoredProcedure);  

                return true; 

            } 
            catch (Exception) 
            {  
                throw;  
            } 
        }
    }
}