using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CooldownTimerEditModeTests
{
    [Test]
    public void Timer_StartsReady_WhenConstructedWithDuration()
    {
        // Arrange
        var t = new CooldownTimer(2f);

        // Act & Assert
        Assert.IsTrue(t.IsReady(), "Timer should be ready immediately when elapsed initialized to duration.");
        Assert.AreEqual(0f, t.Remaining(), 1e-6f, "Remaining should be zero when timer is ready.");
    }

    [Test]
    public void Timer_BecomesReady_AfterTickingDuration()
    {
        // Arrange
        var t = new CooldownTimer(1.5f);
        t.Start();
        Assert.IsFalse(t.IsReady(), "Should not be ready immediately after Start.");

        // Act
        t.Tick(0.5f);
        Assert.IsFalse(t.IsReady(), "Still not ready before full duration.");

        t.Tick(1.0f); // total 1.5f
        // Assert
        Assert.IsTrue(t.IsReady(), "Timer should be ready after ticks sum to duration.");
        Assert.AreEqual(0f, t.Remaining(), 1e-6f);
    }

    [Test]
    public void Timer_Reset_MakesNotReady()
    {
        var t = new CooldownTimer(0.5f);
        t.Start();
        t.Tick(0.6f);
        Assert.IsTrue(t.IsReady(), "Sanity: should be ready after ticking past duration.");

        // Act
        t.Reset();

        // Assert
        Assert.IsFalse(t.IsReady(), "After Reset timer should not be ready.");
        Assert.Greater(t.Remaining(), 0f, "Remaining should be positive after reset.");
    }

    [Test]
    public void Tick_ClampsAtDuration_NotBeyond()
    {
        var t = new CooldownTimer(2f);
        t.Start();
        t.Tick(5f);
        Assert.AreEqual(2f, t.Elapsed, 1e-6f, "Elapsed should be clamped to duration.");
        Assert.IsTrue(t.IsReady());
    }

    [Test]
    public void InvalidArguments_Throw()
    {
        // Negative duration in constructor
        Assert.Throws<System.ArgumentException>(() => new CooldownTimer(-1f));

        var t = new CooldownTimer(1f);
        // Negative delta for Tick should throw
        Assert.Throws<System.ArgumentException>(() => t.Tick(-0.1f));
    }
}
