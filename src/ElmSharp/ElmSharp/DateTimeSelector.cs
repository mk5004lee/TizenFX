/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration of datetime field types for DateTimeSelector.
    /// </summary>
    public enum DateTimeFieldType
    {
        /// <summary>
        /// Indicates Year field.
        /// </summary>
        Year,
        /// <summary>
        /// Indicates Month field.
        /// </summary>
        Month,
        /// <summary>
        /// Indicates Date field.
        /// </summary>
        Date,
        /// <summary>
        /// Indicates Hour field.
        /// </summary>
        Hour,
        /// <summary>
        /// Indicates Minute field.
        /// </summary>
        Minute,
        /// <summary>
        /// Indicates AM/PM field.
        /// </summary>
        AmPm
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>
    /// DateTimeSelector is a widget to display and input date &amp; time values.
    /// This widget displays date and time as per the system's locale settings
    /// (Date includes Day, Month &amp; Year along with the defined separators and Time includes Hour, Minute &amp; AM/PM fields. Separator for AM/PM field is ignored.
    /// </summary>
    public class DateTimeSelector : Layout
    {
        SmartEvent _changed;
        DateTime _cacheDateTime;

        /// <summary>
        /// Creates and initializes a new instance of the DateTimeSelector class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by DateTimeSelector
        ///as a child.It's <see cref="EvasObject"/> type.</param>
        public DateTimeSelector(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of DateTimeSelector class.
        /// </summary>
        protected DateTimeSelector() : base()
        {
        }

        /// <summary>
        /// ItemSelected is raised when Datetime field value changed.
        /// </summary>
        public event EventHandler<DateChangedEventArgs> DateTimeChanged;

        /// <summary>
        /// Gets or sets the datetime format.
        /// </summary>
        /// <remarks>
        /// format is a combination of allowed LIBC date format specifiers like: "%b %d, %Y %I : %M %p".
        /// </remarks>
        public string Format
        {
            get
            {
                return Interop.Elementary.elm_datetime_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_datetime_format_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the upper boundary of DateTime field.
        /// </summary>
        public DateTime MaximumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_max_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_max_set(RealHandle, ref tm);
            }
        }

        /// <summary>
        /// Gets or sets the lower boundary of DateTime field.
        /// </summary>
        public DateTime MinimumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_min_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_min_set(RealHandle, ref tm);
            }
        }

        /// <summary>
        /// Gets or sets the current value of DateTime field.
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_set(RealHandle, ref tm);
                _cacheDateTime = value;
            }
        }

        /// <summary>
        /// Gets whether a field can be visible.
        /// </summary>
        /// <param name="type">Enumeration <see cref="DateTimeFieldType"/></param>
        /// <returns>
        /// The field is visible or not.
        /// Type is bool.If visible, return true.
        /// </returns>
        public bool IsFieldVisible(DateTimeFieldType type)
        {
            return Interop.Elementary.elm_datetime_field_visible_get(RealHandle, (int)type);
        }

        /// <summary>
        /// Sets the field limits of a field.
        /// </summary>
        /// <param name="type">Enumeration <see cref="DateTimeFieldType"/></param>
        /// <param name="minimum">minimum limit</param>
        /// <param name="maximum">maximum limit</param>
        public void SetFieldLimit(DateTimeFieldType type, int minimum, int maximum)
        {
            Interop.Elementary.elm_datetime_field_limit_set(RealHandle, (int)type, minimum, maximum);
        }

        /// <summary>
        /// Gets whether a field can be visible.
        /// </summary>
        /// <param name="type">Enumeration <see cref="DateTimeFieldType"/></param>
        /// <param name="visible">When set as true, the field type visible.</param>
        public void SetFieldVisible(DateTimeFieldType type, bool visible)
        {
            Interop.Elementary.elm_datetime_field_visible_set(RealHandle, (int)type, visible);
        }

        /// <summary>
        /// The callback of Realized Event
        /// </summary>
        protected override void OnRealized()
        {
            base.OnRealized();
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) =>
            {
                DateTime newDateTime = DateTime;
                DateTimeChanged?.Invoke(this, new DateChangedEventArgs(_cacheDateTime, newDateTime));
                DateTime = newDateTime;
            };
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_datetime_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
