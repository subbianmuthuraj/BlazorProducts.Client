﻿using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Shared
{
    public partial class ImageUpload
    {
        private string _fileUploadMessage = "No file chosen";

        [Parameter]
        public string ImgUrl { get; set; }

        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        [Inject]
        public ICountryHttpRepository Repository { get; set; }

        private async Task HandleSelected(InputFileChangeEventArgs e)
        {
            var imageFile = e.File;
            _fileUploadMessage = string.Empty;

            if (imageFile == null)
                return;

            _fileUploadMessage += $"{imageFile.Name}";

            var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);

            using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
            {
                var content = new MultipartFormDataContent();
                content.Headers.ContentDisposition =
                    new ContentDispositionHeaderValue("form-data");
                content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)),
                    "image", imageFile.Name);

                ImgUrl = await Repository.UploadCountryFlagImages(content);

                await OnChange.InvokeAsync(ImgUrl);
            }
        }
    }
}