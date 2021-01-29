using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MessageDecoder;
using MessageEncoder;
using MessageGeneratorNS;
using MessageProcessorNS;
using MessageSenderNs;

using Constants;

namespace robotConsole
{
    class program
    {
        static MsgDecoder msgDecoder;
        static MsgProcessor msgProcessor;

        static MsgSender msgSender;

        static MsgGenerator msgGenerator;
        static MsgEncoder msgEncoder;
        static USBVendor.USBVendor USBCom;

        static void Main(string[] args)
        {
            msgDecoder = new MsgDecoder();
            msgProcessor = new MsgProcessor(1, Utilities.GameMode.Demo);

            msgSender = new MsgSender();

            msgGenerator = new MsgGenerator();
            msgEncoder = new MsgEncoder();
            USBCom = new USBVendor.USBVendor();
            msgEncoder = new MsgEncoder();

            USBCom.OnUSBDataReceivedEvent += msgDecoder.DecodeMsgReceived;
            msgDecoder.OnMessageDecodedEvent += msgProcessor.ProcessRobotDecodedMessage;

            //abbo aux send messages
            msgSender.OnMotorsEnableDisableEvent += msgGenerator.GenerateMessageEnableDisableMotors;
            msgSender.OnSetAsservissementModeEvent += msgGenerator.GenerateMessageSetAsservissementMode;




            //enabling motors
            msgSender.OnMotorsEnableDisable(true);

            //mode d'asservissement en boucle ouverte
            msgSender.OnSetAsservissementMode(AsservissementMode.Disabled);




            Thread.CurrentThread.Join();

        }



    }
}


