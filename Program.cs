using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using ccLib_netCore;
using Microsoft.VisualBasic;

namespace DeployProject
{
    class Program
    {
        static void deployDirectoryRecursive(string srcDir, string dstDir)
        {
            if (Directory.Exists(dstDir))
                RepoManager.DeleteFilesAndFoldersRecursively(dstDir);
            RepoManager.copyFilesNFoldersRecurrsive(srcDir, dstDir);
        }
        static void deployDirectory(string srcDir, string dstDir)
        {
            if (Directory.Exists(dstDir))
                RepoManager.DeleteFilesAndFoldersRecursively(dstDir);
            RepoManager.copyFilesNFolders(srcDir, dstDir);
        }
        static void Main(string[] args)
        {
            // Program expects ccNOosTest Directory as an input
            if (args.Length == 1)
            {

                if (args[0] == "ccACU")
                {
                    //Console.WriteLine("ccACU: Deploying to CR/ccACU Repository");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccOS_Tests\\ccOS\\ccNOos\\tests\\testApps\\SatComACS", "C:\\IMS\\CR\\ccACU_Tests\\ccACU\\SatComACS");
                    //RepoManager.copyFilesNFolders("C:\\IMS\\CR\\ccOS_Tests\\ccOS\\tests\\testApps\\ccACU", "C:\\IMS\\CR\\ccACU_Tests\\ccACU");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccOS_Tests\\ccOS\\tests\\testApps\\ccACU\\apiModules", "C:\\IMS\\CR\\ccACU_Tests\\ccACU\\apiModules");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccOS_Tests\\ccOS\\tests\\testApps\\ccACU\\deviceModules", "C:\\IMS\\CR\\ccACU_Tests\\ccACU\\deviceModules");
                    //File.Copy("C:\\IMS\\CR\\ccOS_Tests\\ccOS\\ccNOos\\tests\\testPlatforms\\Platform_ccOS.hpp", "C:\\IMS\\CR\\ccACU_Tests\\ccACU\\Tests\\Platform_ccOS.hpp", true);
                    return;
                }
                else if (args[0] == "TS4900ACU")
                {
                    //Console.WriteLine("TS4900ACU: Deploying to CS/TS4900ACU Repository");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccACU_Tests\\TS4900\\CompInterfaces", "C:\\IMS\\CS\\TS4900ACU\\application\\CompInterfaces");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccACU_Tests\\TS4900\\ConsoleApp", "C:\\IMS\\CS\\TS4900ACU\\application\\ConsoleApp");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccACU_Tests\\TS4900\\ControllerApp", "C:\\IMS\\CS\\TS4900ACU\\application\\ControllerApp");                    
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccACU_Tests\\TS4900\\ExternalApps", "C:\\IMS\\CS\\TS4900ACU\\application\\ExternalApps");
                    //deployDirectoryRecursive("C:\\IMS\\CR\\ccACU_Tests\\TS4900\\TestApps", "C:\\IMS\\CS\\TS4900ACU\\application\\TestApps");
                    return;
                }
                else if (args[0] == "SatComACS")
                {
                    Console.WriteLine("SatComACS: Deploying to CR/SatComACS Repository");

                    return;
                }
                else if (args[0].Contains("Lib_GripperFW_Tests"))
                {
                    bool madeit = false;
                    string DeployedDir = args[0] + "\\Teensy";
                    string ccNOosDir = args[0] + "\\ccNOos";
                    string ccOSDir = args[0] + "\\ccOS";
                    string FWDir = args[0] + "\\Lib_GripperFW";


                    if (Directory.Exists(args[0]))
                        if (Directory.Exists(ccOSDir))
                            if (Directory.Exists(ccNOosDir))
                                if (Directory.Exists(FWDir))
                                    if (Directory.Exists(DeployedDir))
                                    {
                                        madeit = true;
                                        Console.WriteLine("Lib_GripperFW: Deploying to Teensy Repository");

                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\computeModule");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\computeModule", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\consoleMenu");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\consoleMenu", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\executionSystem");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\executionSystem", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\ioDevice");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\ioDevice", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\packetsAPI");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\packetsAPI", DeployedDir);

                                        RepoManager.CopyDirectoryArduinoMod(FWDir, DeployedDir);
                                        RepoManager.CopyDirectoryArduinoMod(FWDir + "\\apiModules", DeployedDir);
                                        RepoManager.CopyDirectoryArduinoMod(FWDir + "\\deviceModules", DeployedDir);
                                    }

                    if (!madeit)
                        throw (new Exception("A Bad Input Directory"));
                    else
                        Console.WriteLine("\"Lib_GripperFW: Done!");
                    return;
                }
                else if (args[0].Contains("ccNOos_Tests"))
                {
                    bool madeit = false;
                    string DeployedDir = args[0] + "\\Teensy";
                    string ccNOosDir = args[0] + "\\ccNOos";
                    string ccOSDir = args[0] + "\\ccOS";
                    string FWDir = args[0] + "\\Tests";


                    if (Directory.Exists(args[0]))
                        if (Directory.Exists(ccOSDir))
                            if (Directory.Exists(ccNOosDir))
                                if (Directory.Exists(FWDir))
                                    if (Directory.Exists(DeployedDir))
                                    {
                                        madeit = true;
                                        Console.WriteLine("ccNOos_Tests: Deploying to Teensy Repository");

                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\computeModule");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\computeModule", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\consoleMenu");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\consoleMenu", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\executionSystem");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\executionSystem", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\ioDevice");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\ioDevice", DeployedDir);
                                        RepoManager.FixFileBriefNLicense(ccNOosDir + "\\packetsAPI");
                                        RepoManager.CopyDirectoryArduinoMod(ccNOosDir + "\\packetsAPI", DeployedDir);

                                        RepoManager.CopyDirectoryArduinoMod(FWDir, DeployedDir);
                                        RepoManager.CopyDirectoryArduinoMod(FWDir + "\\apiModules", DeployedDir);
                                        RepoManager.CopyDirectoryArduinoMod(FWDir + "\\deviceModules", DeployedDir);
                                    }

                    if (!madeit)
                        throw (new Exception("A Bad Input Directory"));
                    else
                        Console.WriteLine("\"ccNOos_Tests: Done!");
                    return;
                }
                else
                {
                    Console.WriteLine("FAILURE:( Unrecongnized deploy project name input");
                    return;
                }



                //////////////////////////////////////////////////////////
                ////// this is for the FlatFiles project
                //string objDIR = Path.GetFullPath(args[2]);
                //bool notOnce = true;
                //if (Directory.Exists(objDIR))
                //{
                //    foreach (string filenamestring in Directory.GetFiles(objDIR))
                //    {
                //        if (filenamestring.EndsWith(".i"))
                //        {
                //            Console.Write($"Processing {filenamestring} ...");
                //            notOnce = false;
                //            char[] seps = { '\n', '\r' };
                //            string[] lines = File.ReadAllText(filenamestring).Split(seps, StringSplitOptions.RemoveEmptyEntries);
                //            string outText = "";
                //            foreach (string lString in lines)
                //            {
                //                if (!String.IsNullOrWhiteSpace(lString))
                //                    outText += lString + "\n";
                //            }
                //            Console.Write("Saving ...");
                //            File.WriteAllText(filenamestring.Replace(".i", ".cpp"), outText);
                //            Console.Write("Done!\n");
                //        }
                //    }

                //    if (notOnce)
                //        Console.WriteLine("No .i Files to Process this Time.");
                //    else
                //        Console.WriteLine("Pre-Processed Files Cleaned and Saved for Flat Console Test!");
                //    return;

                //}
                //else
                //{
                //    Console.WriteLine("FAILURE:( " + objDIR + " does not exist!");
                //    return;
                //}
            }
            else
            {
                Console.WriteLine("FAILURE:( exactly 1 input was not received");
                return;
            }
        }
    }
}
