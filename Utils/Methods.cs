using Microsoft.AspNetCore.Mvc;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppMVC.Utils
{
 

    public static class MessageHelper
    {
        private static string _message = null!;
        private static Controller _controller = null!;
        private enum MessageType
        {
            Success,
            Error
        }

        private static void SetMessage(MessageType type)
        {
            _controller.TempData["MessageText"] = _message;
            _controller.TempData["MessageType"] = type.ToString(); 
        }

        public static void SetMessageSucess(Controller controller, string message)
        {
            _message = message;
            _controller = controller;
            SetMessage(MessageType.Success);
        }

        public static void SetMessageError(Controller controller, string message)
        {
            _controller = controller;
            _message = message;
            SetMessage(MessageType.Error);
        }
    }

}
