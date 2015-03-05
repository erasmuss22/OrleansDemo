using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Orleans;

namespace Silo
{
    public class WorkerRole : RoleEntryPoint
    {
        Orleans.Runtime.Host.AzureSilo silo;

        public override bool OnStart()
        {
            // Do other silo initialization – for example: Azure diagnostics, etc 

            silo = new Orleans.Runtime.Host.AzureSilo();

            return silo.Start(
                RoleEnvironment.DeploymentId, RoleEnvironment.CurrentRoleInstance);
        }
        public override void OnStop() { silo.Stop(); }
        public override void Run() { silo.Run(); } 
    }
}
