﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using BioBookingV2.DTO;
using BioBookingV2.DAL;

namespace BioBookingV2
{
    public partial class CreateMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            decimal Price = 0;
            // Todo error handling on decimal (Raise friendly error dialog)
            if (Decimal.TryParse(InputPrice.Value, out Price))
            {
                // Open SQL connection
                SQLConnector con = new SQLConnector();

                // Get file extension (example: .png)
                var FileExtension = Path.GetExtension(FileUploadPoster.PostedFile.FileName).ToLower();

                // Get next identity of Movie to insert poster
                int NextMovieId = con.GetTableNextId("Movie");

                // Get poster file name and server location
                string ImagePath = Server.MapPath("~/Content/Images/");
                string ImageName = "Poster" + NextMovieId.ToString() + FileExtension;


                if (FileUploadPoster.HasFile)
                {
                    // Save uploaded image to server
                    bool success = FileUpload(ImagePath + ImageName, FileExtension);

                    if (success)
                    {
                        // Create Movie object to insert
                        MovieDTO NewMovie = new MovieDTO
                        {
                            Title = InputTitle.Value,
                            Description = InputDescription.Value,
                            PosterFileName = (FileUploadPoster.HasFile ? ImageName : "NotMadeYet.png"),
                            Price = Price
                        };
                        // Insert new movie into table
                        NewMovie = (MovieDTO)(con.CreateObject(NewMovie));
                    }
                }
                else
                {
                    LabelUploadText.Text = "Billede til film skal uploads!";
                    LabelUploadText.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private bool FileUpload(string ImagePath, string FileExtension)
        {
            bool output = false;
            // Open SQL connection
            SQLConnector con = new SQLConnector();

            // Create and populate list of allowed file extensions to upload
            List<string> AllowedExtensions = new List<string>
            {
                ".gif",
                ".jpeg",
                ".jpg",
                ".png"
            };
            // Check if file extension is allowed and save the file
            if (AllowedExtensions.Contains(FileExtension))
            {
                try
                {
                    FileUploadPoster.SaveAs(ImagePath);
                    output = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                LabelUploadText.Text = "Filen skal være i et af følgende formater: .gif, .jpeg, .jpg, .png";
                LabelUploadText.ForeColor = System.Drawing.Color.Red;
            }
            return output;
        }
    }
}