/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

namespace Tizen.NUI
{

    /// <summary>
    /// Rotation Class
    /// </summary>
    public class Rotation : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Rotation(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Rotation obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Rotation()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// To make Rotation instance be disposed.
        /// </summary>
        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Rotation(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">First Rotation</param>
        /// <param name="arg2">Second Rotation</param>
        /// <returns>A Rotation containing the result of the Addition</returns>
        public static Rotation operator +(Rotation arg1, Rotation arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">First Rotation</param>
        /// <param name="arg2">Second Rotation</param>
        /// <returns>A Rotation containing the result of the subtract</returns>
        public static Rotation operator -(Rotation arg1, Rotation arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// Unary Negation operator.
        /// </summary>
        /// <param name="arg1">First Rotation</param>
        /// <returns>A Rotation containing the negated result</returns>
        public static Rotation operator -(Rotation arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">First Rotation</param>
        /// <param name="arg2">Second Rotation</param>
        /// <returns>A Rotation containing the result of the Multiplication</returns>
        public static Rotation operator *(Rotation arg1, Rotation arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">Rotation</param>
        /// <param name="arg2">The vector to multiply</param>
        /// <returns>A Rotation containing the result of the multiplication</returns>
        public static Vector3 operator *(Rotation arg1, Vector3 arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Scale operator.
        /// </summary>
        /// <param name="arg1">Rotation</param>
        /// <param name="arg2">A value to scale by</param>
        /// <returns>A Rotation containing the result of the scaling</returns>
        public static Rotation operator *(Rotation arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">First Rotation</param>
        /// <param name="arg2">Second Rotation</param>
        /// <returns>A Rotation containing the result of the scaling</returns>
        public static Rotation operator /(Rotation arg1, Rotation arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Scale operator.
        /// </summary>
        /// <param name="arg1">Rotation</param>
        /// <param name="arg2">A value to scale by</param>
        /// <returns>A Rotation containing the result of the scaling</returns>
        public static Rotation operator /(Rotation arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Rotation() : this(NDalicPINVOKE.new_Rotation__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor from an axis and angle.
        /// </summary>
        /// <param name="angle">The angle around the axis</param>
        /// <param name="axis">The vector of the axis</param>
        public Rotation(Radian angle, Vector3 axis) : this(NDalicPINVOKE.new_Rotation__SWIG_1(Radian.getCPtr(angle), Vector3.getCPtr(axis)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// (0.0f,0.0f,0.0f,1.0f)
        /// </summary>
        public static Rotation IDENTITY
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Rotation_IDENTITY_get();
                Rotation ret = (cPtr == global::System.IntPtr.Zero) ? null : new Rotation(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Helper to check if this is an identity quaternion.
        /// </summary>
        /// <returns>True if this is identity quaternion</returns>
        public bool IsIdentity()
        {
            bool ret = NDalicPINVOKE.Rotation_IsIdentity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts the quaternion to an axis/angle pair.
        /// </summary>
        /// <param name="axis">the result of axis</param>
        /// <param name="angle">the result of angle Angle in radians</param>
        /// <returns>True if converted correctly</returns>
        public bool GetAxisAngle(Vector3 axis, Radian angle)
        {
            bool ret = NDalicPINVOKE.Rotation_GetAxisAngle(swigCPtr, Vector3.getCPtr(axis), Radian.getCPtr(angle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Add(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Add(swigCPtr, Rotation.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Subtract(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Subtract__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Multiply(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Multiply__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(Vector3 other)
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Rotation_Multiply__SWIG_1(swigCPtr, Vector3.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Divide(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Divide__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Multiply(float scale)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Multiply__SWIG_2(swigCPtr, scale), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Divide(float scale)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Divide__SWIG_1(swigCPtr, scale), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Subtract()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation AddAssign(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_AddAssign(swigCPtr, Rotation.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation SubtractAssign(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_SubtractAssign(swigCPtr, Rotation.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation MultiplyAssign(Rotation other)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_MultiplyAssign__SWIG_0(swigCPtr, Rotation.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation MultiplyAssign(float scale)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_MultiplyAssign__SWIG_1(swigCPtr, scale), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation DivideAssign(float scale)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_DivideAssign(swigCPtr, scale), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Rotation rhs)
        {
            bool ret = NDalicPINVOKE.Rotation_EqualTo(swigCPtr, Rotation.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Rotation rhs)
        {
            bool ret = NDalicPINVOKE.Rotation_NotEqualTo(swigCPtr, Rotation.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the rotation
        /// </summary>
        /// <returns>The length of the rotation</returns>
        public float Length()
        {
            float ret = NDalicPINVOKE.Rotation_Length(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the squared length of the rotation
        /// </summary>
        /// <returns>The squared length of the rotation</returns>
        public float LengthSquared()
        {
            float ret = NDalicPINVOKE.Rotation_LengthSquared(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Normalizes this to unit length.
        /// </summary>
        public void Normalize()
        {
            NDalicPINVOKE.Rotation_Normalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Normalized.
        /// </summary>
        /// <returns>A normalized version of this rotation</returns>
        public Rotation Normalized()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Normalized(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Conjugates this rotation.
        /// </summary>
        public void Conjugate()
        {
            NDalicPINVOKE.Rotation_Conjugate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inverts this rotation.
        /// </summary>
        public void Invert()
        {
            NDalicPINVOKE.Rotation_Invert(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Performs the logarithm of a rotation
        /// </summary>
        /// <returns>A rotation representing the logarithm</returns>
        public Rotation Log()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Log(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Performs an exponent
        /// </summary>
        /// <returns>A rotation representing the exponent</returns>
        public Rotation Exp()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Exp(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the dot product of two rotations.
        /// </summary>
        /// <param name="q1">The first rotation</param>
        /// <param name="q2">The second rotation</param>
        /// <returns>The dot product of the two rotations</returns>
        public static float Dot(Rotation q1, Rotation q2)
        {
            float ret = NDalicPINVOKE.Rotation_Dot(Rotation.getCPtr(q1), Rotation.getCPtr(q2));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Linear Interpolation (using a straight line between the two rotations).
        /// </summary>
        /// <param name="q1">The start rotation</param>
        /// <param name="q2">The end rotation</param>
        /// <param name="t">A progress value between 0 and 1</param>
        /// <returns>The interpolated rotation</returns>
        public static Rotation Lerp(Rotation q1, Rotation q2, float t)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Lerp(Rotation.getCPtr(q1), Rotation.getCPtr(q2), t), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Spherical Linear Interpolation (using the shortest arc of a great circle between the two rotations).
        /// </summary>
        /// <param name="q1">The start rotation</param>
        /// <param name="q2">The end rotation</param>
        /// <param name="progress">A progress value between 0 and 1</param>
        /// <returns>The interpolated rotation</returns>
        public static Rotation Slerp(Rotation q1, Rotation q2, float progress)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Slerp(Rotation.getCPtr(q1), Rotation.getCPtr(q2), progress), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// This version of Slerp, used by Squad, does not check for theta > 90.
        /// </summary>
        /// <param name="q1">The start rotation</param>
        /// <param name="q2">The end rotation</param>
        /// <param name="t">A progress value between 0 and 1</param>
        /// <returns>The interpolated rotation</returns>
        public static Rotation SlerpNoInvert(Rotation q1, Rotation q2, float t)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_SlerpNoInvert(Rotation.getCPtr(q1), Rotation.getCPtr(q2), t), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Spherical Cubic Interpolation.
        /// </summary>
        /// <param name="start">The start rotation</param>
        /// <param name="end">The end rotation</param>
        /// <param name="ctrl1">The control rotation for q1</param>
        /// <param name="ctrl2">The control rotation for q2</param>
        /// <param name="t">A progress value between 0 and 1</param>
        /// <returns>The interpolated rotation</returns>
        public static Rotation Squad(Rotation start, Rotation end, Rotation ctrl1, Rotation ctrl2, float t)
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Rotation_Squad(Rotation.getCPtr(start), Rotation.getCPtr(end), Rotation.getCPtr(ctrl1), Rotation.getCPtr(ctrl2), t), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the shortest angle between two rotations in Radians.
        /// </summary>
        /// <param name="q1">The first rotation</param>
        /// <param name="q2">The second rotation</param>
        /// <returns>The angle between the two rotation</returns>
        public static float AngleBetween(Rotation q1, Rotation q2)
        {
            float ret = NDalicPINVOKE.Rotation_AngleBetween(Rotation.getCPtr(q1), Rotation.getCPtr(q2));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}