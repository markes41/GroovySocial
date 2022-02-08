using Groov.Data.Base.Custom;
using Groov.Data.Base.Logs;
using Groov.Library.Data.Entities;
using Groov.Library.Data.Manager;
using Groov.Web.Helpers;
using GroovySocial.Helpers;
using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace GroovySocial.Models
{
    public class ProfileModel
    {
        /// <summary>
        /// Returns the file in the request as byte[]
        /// </summary>
        public async static Task<byte[]> GetFileInRequest(HttpRequest request)
        {
            try
            {
                // Create a temp path file
                var path = Path.GetTempFileName();

                // Get the bytearray of the image
                return await FileHelper.ConvertFileToByteArray(request.Form.Files, path);
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "ChangeProfilePicture()");
                return null;
            }
        }

        /// <summary>
        /// Convert the profile image upload to byte[] and update the user with the new image
        /// </summary>
        public async static Task<bool> SaveProfilePictureChange(UserViewModel userViewModel, HttpRequest request)
        {
            try
            {
                // Convert the file in request to byte array
                var fileByteArray = await GetFileInRequest(request);

                var userDto = new User();

                // Pass the values from viewmodel to dto
                Mapper.CopyProperties(userViewModel, userDto);

                // Update the profile_image
                userDto.Profile_Image = fileByteArray;

                // Save the changes
                var saved = await User_Manager.Save(userDto, userDto.Id == 0);

                if (saved)
                {
                    // Convert image to base64
                    var imageBase64 = Convert.ToBase64String(fileByteArray);

                    // Update the profile_image
                    userViewModel.Profile_Image = imageBase64;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "ChangeProfilePicture()");
                return false;
            }
        }
    }
}
