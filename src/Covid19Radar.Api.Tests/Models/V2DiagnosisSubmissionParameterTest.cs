﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using Covid19Radar.Api.Extensions;
using Covid19Radar.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Covid19Radar.Api.Tests.Models
{
    [TestClass]
    [TestCategory("Models")]
    public class V2DiagnosisSubmissionParameterTest
    {
        private const int KEY_LENGTH = 16;

        [TestMethod]
        public void CreateMethod()
        {
            // action
            var model = new DiagnosisSubmissionParameter();
        }

        [TestMethod]
        public void PropertiesTest()
        {
            // preparation
            var model = new DiagnosisSubmissionParameter();
            // model property access
            Helper.ModelTestHelper.PropetiesTest(model);
        }

        [DataTestMethod]
        [DataRow("KEYDATA", 0, 0, true)]
        [DataRow("KEYDATA", 145, 0, false)]
        [DataRow("KEYDATA", 144, -15, false)]
        [DataRow("KEYDATA", 144, -14, true)]
        [DataRow("KEYDATA", 144, -6, true)]
        [DataRow("KEYDATA", 144, -5, true)]
        [DataRow("KEYDATA", 144, -4, true)]
        [DataRow("KEYDATA", 144, -3, true)]
        [DataRow("KEYDATA", 144, -2, true)]
        [DataRow("KEYDATA", 144, -1, true)]
        [DataRow("KEYDATA", 144, 0, true)]
        [DataRow("KEYDATA", 144, 1, false)]
        public void KeyValidationTest(string keyData, int rollingPeriod, int rollingStartNummberDayOffset, bool isValid)
        {
            var dateTime = DateTime.UtcNow.Date;
            var key = new DiagnosisSubmissionParameter.Key() { KeyData = keyData, RollingPeriod = (uint)rollingPeriod, RollingStartNumber = dateTime.AddDays(rollingStartNummberDayOffset).ToRollingStartNumber() };
            Assert.AreEqual(isValid, key.IsValid());
        }
    }
}
