using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Set the desired capabilities
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", "notepad.exe");

            // Create the WindowsDriver instance
            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);



            // Input text into Notepad
            driver.FindElementByName("Text Editor").SendKeys("Hello, World!");

            System.Threading.Thread.Sleep(2000);

            // Save the file
            driver.FindElementByName("File").Click();

            driver.FindElementByAccessibilityId("4").Click();
            System.Threading.Thread.Sleep(2000);

            //send keys to file locators 
            WindowsElement fileNameInput = driver.FindElementByAccessibilityId("1001");
            fileNameInput.SendKeys("FirstTest.txt");

            //to save 
            WindowsElement savebutton = driver.FindElementByName("Save");
            savebutton.Click();

            driver.CloseApp();



            // to reopen
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            // Wait for the Notepad window to load
            System.Threading.Thread.Sleep(2000);

            //open file
            driver.FindElementByName("File").Click();
            driver.FindElementByAccessibilityId("2").Click();

            System.Threading.Thread.Sleep(2000);

            // find the saved file
            fileNameInput= driver.FindElementByXPath("//Edit[@Name='File name:']");
            fileNameInput.SendKeys("FirstTest.txt");

            //click the open button
            WindowsElement openButton = driver.FindElementByAccessibilityId("1");
            openButton.Click();

            System.Threading.Thread.Sleep(3000);

            // Open the file
            driver.FindElementByName("File").Click();

            System.Threading.Thread.Sleep(3000);

            //open and click the save as
            driver.FindElementByAccessibilityId("4").Click();

            System.Threading.Thread.Sleep(3000);

            //clear the existing file name

            fileNameInput = driver.FindElementByAccessibilityId("1001");
            System.Threading.Thread.Sleep(3000);
            fileNameInput.Clear();

            // to rename the file (FirstTest to FirstTask)
            fileNameInput.SendKeys("FirstTask.txt");

            //save the name
            savebutton = driver.FindElementByName("Save");
            savebutton.Click();


            // Wait for Save As dialog to appear again
            System.Threading.Thread.Sleep(2000);

            // Close Notepad
            driver.CloseApp();
            driver.Quit();
        }

    }

}






