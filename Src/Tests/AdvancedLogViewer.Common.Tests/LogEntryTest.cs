﻿using AdvancedLogViewer.Common.Parser;
using System;
using System.Globalization;
using NUnit.Framework;

namespace AdvancedLogViewer.Common.Tests
{      
    /// <summary>
    ///This is a test class for LogEntryTest and is intended
    ///to contain all LogEntryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class LogEntryTest
    {
        /// <summary>
        ///A test for ParseDate
        ///</summary>
        [Test]
        public void ParseDateTest()
        {
            LogEntry target = new LogEntry(); // TODO: Initialize to an appropriate value
            string value = "30.10.1981";
            Assert.IsTrue(target.SaveValue(PatternItemType.Date, value));
            Assert.AreEqual(value, target.DateText);

            string value2 = "10:11:12,123";
            Assert.IsTrue(target.SaveValue(PatternItemType.Time, value2));
            Assert.AreEqual(value + " " + value2, target.DateText);

            string dateFormat = "dd.MM.yyyy HH:mm:ss,fff";
            Assert.IsTrue(target.ParseDate(dateFormat));
            Assert.AreEqual(DateTime.ParseExact(value + " " + value2, dateFormat, CultureInfo.InvariantCulture), target.Date);

            Assert.IsFalse(target.ParseDate("dd.MM"));
            Assert.AreEqual(DateTime.MinValue, target.Date);
        }


        /// <summary>
        ///A test for SaveValue
        ///</summary>
        [Test]
        public void SaveValueTest()
        {
            LogEntry target = new LogEntry(); // TODO: Initialize to an appropriate value           
            string value;

            value = "SomeClass";
            Assert.IsTrue(target.SaveValue(PatternItemType.Class, value));
            Assert.AreEqual(value, target.Class);


            value = "30.10.1981";            
            Assert.IsTrue(target.SaveValue(PatternItemType.Date, value));
            Assert.AreEqual(value, target.DateText);
            
            string value2 = "10:11:12,123";
            Assert.IsTrue(target.SaveValue(PatternItemType.Time, value2));
            Assert.AreEqual(value + " " + value2, target.DateText);
            
            string dateFormat = "dd.MM.yyyy HH:mm:ss,fff";
            Assert.IsTrue(target.ParseDate(dateFormat));
            Assert.AreEqual(DateTime.ParseExact(value + " " + value2, dateFormat, CultureInfo.InvariantCulture), target.Date);


            value = "Some message";
            Assert.IsTrue(target.SaveValue(PatternItemType.Message, value));
            Assert.AreEqual(value, target.Message);
            
            value2 = "Second part of message";
            Assert.IsTrue(target.SaveValue(PatternItemType.Message, value2));
            Assert.AreEqual(value + value2, target.Message);


            value = "ThreadName";
            Assert.IsTrue(target.SaveValue(PatternItemType.Thread, value));
            Assert.AreEqual(value, target.Thread);


            value = "DEBUG";
            Assert.IsTrue(target.SaveValue(PatternItemType.Type, value));
            Assert.AreEqual(value, target.Type);
            Assert.AreEqual(LogType.DEBUG, target.LogType);

        }
    }
}