// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class for creating progress notifications
    /// </summary>
    public class ProgressNotification : Notification
    {
        /// <summary>
        /// Class contructor
        /// </summary>
        public ProgressNotification()
        {
            int ret;

            _handle = Interop.Notification.Create(NotificationType.Progress);
            if (_handle.IsInvalid)
            {
                ret = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to create Progress Notification");
            }

            ret = Interop.Notification.SetLayout(_handle, NotiLayout.Progress);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set progress layout");
            }

            ret = Interop.Notification.SetProgressSize(_handle, 100.0);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set default progress size");
            }

            NotificationType = NotificationType.Progress;
        }

        internal ProgressNotification(Interop.Notification.SafeNotificationHandle handle)
        {
            _handle = handle;

            NotificationType = NotificationType.Progress;
        }

        /// <summary>
        /// Gets and sets maximum value for progress ticker. Defaults to 100.
        /// </summary>
        public double Maximum
        {
            get
            {
                double size;
                int ret = Interop.Notification.GetProgressSize(_handle, out size);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "get progress size failed");
                    return 100.0;
                }

                return size;
            }
            set
            {
                if(value < 0)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "wrong value for progress size");
                }

                int ret = Interop.Notification.SetProgressSize(_handle, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "set progress size failed");
                }
            }
        }

        /// <summary>
        /// gets and sets current progress value for ticker. Defaults to 0.
        /// </summary>
        public double ProgressValue
        {
            get
            {
                double size;
                int ret = Interop.Notification.GetProgress(_handle, out size);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "get progress failed");
                    return 0;
                }

                return size;
            }
            set
            {
                if(value < 0 || value > Maximum)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "wrong value for progress value");
                }

                int ret = Interop.Notification.SetProgress(_handle, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "set progress failed");
                }
            }
        }
    }
}
