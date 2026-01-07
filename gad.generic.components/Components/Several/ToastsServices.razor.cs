using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.generic.components.Components.Several
{
    public partial class ToastsServices
    {
        [Parameter]
        public int Time { get; set; }
        private string Visible = "none";
        private string MessageTitle = string.Empty;
        private string Message = string.Empty;
        private string BackgroundColor=string.Empty;
        private string ColorText = string.Empty;
        public async Task ShowMessage(string color, string messageTitle, string message)
        {
            Visible = "block";
            MessageTitle = messageTitle;
            Message = message;
            Colors(color);
            StateHasChanged();
            await Task.Delay(Time);
            Visible = "none";
            StateHasChanged();
        }
        public void Open()
        {
            Visible = "block";
            StateHasChanged();
        }

        public void Close()
        {
            Visible = "none";
            StateHasChanged();
        }
        public void Colors(string op)
        {
            switch (op)
            {
                case "success":
                    BackgroundColor = "#198754";
                    ColorText = "#f8f9fa";
                break;
                case "error":
                    BackgroundColor = "#dc3545";
                    ColorText = "#f8f9fa";
                break;
                case "info":
                    BackgroundColor = "#0dcaf0";
                    ColorText = "#f8f9fa"; 
                break;
                case "warning":
                    BackgroundColor = "#ffc107";
                    ColorText = "#FFFFFF";
                break;
                case "white":
                    BackgroundColor = "#fff";
                    ColorText = "#343a40";
                break;
                case "light":
                    BackgroundColor = "#f8f9fa";
                    ColorText = "#343a40";
                break;
                case "dark":
                    BackgroundColor = "#212529";
                    ColorText = "#f8f9fa";
                break;
                default:
                    BackgroundColor = "#fff";
                    ColorText = "#343a40";
                    break;
            }
        }
    }
}

