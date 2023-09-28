﻿using NUnit.Framework;

namespace Clock
{
    [TestFixture()]
    internal class ClockTests
    {
        Clock testClock;

        [SetUp()]
        public void Setup()
        {
            testClock = new Clock();
        }

        [Test()]
        public void TestClockInitialize()
        {
            Assert.That(testClock.Time(), Is.EqualTo("00:00:00"));
        }

        [Test()]
        public void TestClockSecondIncrement()
        {
            testClock.Tick();
            Assert.That(testClock.Time(), Is.EqualTo("00:00:01"));
        }

        [Test()]
        public void TestClockMinuteIncrement() //Test for day and hour
        {
            for (int i = 0; i < 60; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time(), Is.EqualTo("00:01:00"));
        }

        [Test()]
        public void TestClockHourIncrement()
        {
            for (int i = 0; i < 3600; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time(), Is.EqualTo("01:00:00"));
        }

        [Test()]
        public void TestClockDayIncrement()
        {
            for (int i = 0; i < 86400; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time(), Is.EqualTo("00:00:00"));
        }

        [Test()]
        public void TestClockReset()
        {
            testClock.Tick();
            testClock.ResetClock();

            Assert.That(testClock.Time(), Is.EqualTo("00:00:00"));
        }
    }
}
