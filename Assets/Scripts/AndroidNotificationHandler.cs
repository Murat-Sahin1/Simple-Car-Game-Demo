using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string ChannelId = "notification_channel";

   public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = ChannelId, //Channel id
            Name = "Notification Channel", //Channel name
            Description = "Off-Road Game Notifications",
            Importance = Importance.Default //Importance of the notification channel
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification
        {
            Title = "Your Car's Energy Recharged!",
            Text = "Your energy has recharged Off-Roader! Let's dive into the arena again!",
            SmallIcon = "icon_0",
            LargeIcon = "icon_0",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
#endif
}
