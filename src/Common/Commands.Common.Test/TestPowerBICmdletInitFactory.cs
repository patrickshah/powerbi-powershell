﻿/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License.
 */

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.PowerBI.Common.Client;
using Microsoft.PowerBI.Common.Abstractions;
using Microsoft.PowerBI.Common.Abstractions.Interfaces;

namespace Microsoft.PowerBI.Commands.Common.Test
{
    public class TestPowerBICmdletInitFactory : PowerBIClientCmdletInitFactory
    {
        public IPowerBIProfile Profile { get; set; }

        public TestLogger Logger
        {
            get
            {
                if(this.LoggerFactory is TestLoggerFactory logger)
                {
                    return logger.Logger;
                }

                return null;
            }
        }

        public TestPowerBICmdletInitFactory(FakeHttpClientHandler clientHandler) : 
            base(new TestLoggerFactory(), new ModuleDataStorage(), new TestAuthenticator(), new PowerBISettings(), new TestClient(clientHandler))
        {
        }

        public void SetProfile(IPowerBIProfile profile = null)
        {
            if(profile == null)
            {
                this.Profile = new TestProfile();
            }
            else if(this.Profile != profile)
            {
                this.Profile = profile;
            }

            this.Storage.SetItem("profile", this.Profile);
        }
    }
}