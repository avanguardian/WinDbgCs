﻿using CsDebugScript;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbgEngTest
{
    /// <summary>
    /// E2E tests for verifying various functionalities of CsScript against NativeDumpTest.VS2013.exe.
    /// </summary>
    [TestClass]
    [DeploymentItem(DefaultDumpFile)]
    public class NativeDumpTest32GCC : TestBase
    {
        private const string DefaultDumpFile = @"..\..\..\dumps\NativeDumpTest.gcc.mdmp";
        private const string DefaultModuleName = "NativeDumpTest_gcc";
        private const string DefaultSymbolPath = @"..\..\..\dumps\";

        private static NativeDumpTest testRunner;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            SyncStart();
            testRunner = new NativeDumpTest(DefaultDumpFile, DefaultModuleName, DefaultSymbolPath);
            testRunner.TestSetup();
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            SyncStop();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void TestModuleExtraction()
        {
            testRunner.TestModuleExtraction();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void ReadingFloatPointTypes()
        {
            testRunner.ReadingFloatPointTypes();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void GettingClassStaticMember()
        {
            // TODO: cv2pdb doesn't export static members
            // testRunner.GettingClassStaticMember();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckProcess()
        {
            testRunner.CheckProcess();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckDebugger()
        {
            testRunner.CheckDebugger();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CurrentThreadContainsNativeDumpTestCpp()
        {
            testRunner.CurrentThreadContainsNativeDumpTestCpp();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CurrentThreadContainsNativeDumpTestMainFunction()
        {
            testRunner.CurrentThreadContainsNativeDumpTestMainFunction();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckMainArguments()
        {
            // TODO: cv2pdb exports arguments as local variable
            //testRunner.CheckMainArguments();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckThread()
        {
            testRunner.CheckThread();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckCodeArray()
        {
            testRunner.CheckCodeArray();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckCodeFunction()
        {
            testRunner.CheckCodeFunction();
        }

        [TestMethod]
        [TestCategory("NativeDumpTests")]
        public void CheckMainLocals()
        {
            testRunner.CheckDefaultTestCaseLocals();
        }
    }
}
