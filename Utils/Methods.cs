using Microsoft.AspNetCore.Mvc;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppMVC.Utils
{
    public static class Methods
    {
        private static string _message;
        public enum ETipeMessage
        {
            Sucess = 1,
            Error = 2
        }
        private static void ClientMessage(ETipeMessage tipo)
        { 
     
        }

        public static void ClientMessageError(string message)
        {
            _message = message; 
            ClientMessage(ETipeMessage.Error);
        }

        public static void ClientMessageSucess(string message)
        {
            _message = message;
            ClientMessage(ETipeMessage.Sucess);
        }
    }

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
