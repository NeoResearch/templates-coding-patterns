using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Neo.SmartContract
{
    public class Mirror : Framework.SmartContract
    {
        public static bool Main(string operation, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
               return true;
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                Runtime.Notify("Mirror!");
                Runtime.Notify(operation);
                Runtime.Notify("This hash:");
                Runtime.Notify(ExecutionEngine.ExecutingScriptHash);
                return true;
            }
            return false;
        }
    }
}

Hash: 9b11d98a5afa2e5c45857a9ad12628bd7d16c083

Address (script hash): 83c0167dbd2826d19a7a85455c2efa5a8ad9119b


===================================================================


using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Neo.SmartContract
{
    public class Mirror2 : Framework.SmartContract
    {
        public delegate bool Mirror(string method, object[] args);
        public static readonly byte[] mirrorcont = "83c0167dbd2826d19a7a85455c2efa5a8ad9119b".HexToBytes();

        public static bool Main(string operation, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
               return true;
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                Runtime.Notify("Mirror2!");
                Runtime.Notify(operation);


                Runtime.Notify("will call");
                Runtime.Notify(mirrorcont);

                 var Contract = (Mirror)mirrorcont.ToDelegate();
                 var transferSuccessful = (bool)Contract("testing", args);
                 Runtime.Notify(transferSuccessful);

                return true;
            }
            return false;
        }
    }
}


Hash: 255805419d1379b7eb17d1be45c617185651c263
