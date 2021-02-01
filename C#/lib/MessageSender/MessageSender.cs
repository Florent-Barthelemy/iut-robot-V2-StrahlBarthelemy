using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Constants;
using EventArgsLibrary;

namespace MessageSenderNs
{
    public class MsgSender
    {


        public MsgSender() { }

        //consigne de vitesse polaire
        public event EventHandler<PolarSpeedArgs> OnPolarSpeedArgsArgs;

        public virtual void OnSpeedConsigneToMotorArgs(int robotID, double vx, double vTheta)
        {
            OnPolarSpeedArgsArgs?.Invoke(this, new PolarSpeedArgs
            {
                RobotId = robotID,
                Vx = vx,
                Vy = 0,
                Vtheta = vTheta
            });
        }

        //asservissement mode
        public event EventHandler<ByteEventArgs> OnSetAsservissementModeEvent;
        public virtual void OnSetAsservissementMode(AsservissementMode mode)
        {
            byte b = 0;

            if (mode == AsservissementMode.Disabled)
                b = 0;
            if (mode == AsservissementMode.Independant)
                b = 2;
            if (mode == AsservissementMode.Polar)
                b = 1;

            OnSetAsservissementModeEvent?.Invoke(this, new ByteEventArgs
            {
                Value = b
            });
        }


        //enabling / disabling motors
        public event EventHandler<EventArgsLibrary.BoolEventArgs> OnMotorsEnableDisableEvent;
        public virtual void OnMotorsEnableDisable(bool state)
        {
            OnMotorsEnableDisableEvent?.Invoke(this, new EventArgsLibrary.BoolEventArgs
            {
                value = true
            });
        }
    }
}
