﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Shared
{
    public partial class Confirmation
    {
        private string _modalDisplay;
        private bool _showBackdrop;

        [Parameter]
        public string BodyMessage { get; set; }

        [Parameter]
        public EventCallback OnOKClicked { get; set; }

        public void Show()
        {
            _modalDisplay = "block;";
            _showBackdrop = true;
            StateHasChanged();
        }

        public void Hide()
        {
            _modalDisplay = "none;";
            _showBackdrop = false;
            StateHasChanged();
        }
    }
}