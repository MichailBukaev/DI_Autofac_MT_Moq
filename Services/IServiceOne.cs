﻿using System.Threading.Tasks;

namespace Services
{
  public interface IServiceOne
  {
    string Loading();
    string Saving(string name);
    void SetDataName(string dataName);
    void PushNotification(string text);
    void SendEmail(string text);
    Task<string> SendSms(string text);
  }
}