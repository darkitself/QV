using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public enum RequestsTypes
    {
        Autorization = 1, Registration = 2, GetAllUserData = 3, DeleteUserCard = 4,
        DeleteReceivedCard = 5, ChangeUserCardName = 6, ChangeReceivedCardName = 7,
        CreateUserCard = 8, ChangeUserCard = 9, ChangeUserData = 10, ReceiveCard = 11, DeleteUser = 12
    }
}
