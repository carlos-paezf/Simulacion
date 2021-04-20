using System;
using System.Collections.Generic;
using Random = System.Random;

public class Poisson{
  private int          lambda           = 5;
  private int          numEvents        = 100;
  private List<double> _eventNum        = new List<double>();
  private List<double> _interEventTimes = new List<double>();
  private List<double> _eventTimes      = new List<double>();
  private double       _eventTime;

  public void InverseCdf() {
    var random = new Random();
    
    for (int i = 0; i <= numEvents; i++) {
      _eventNum.Add(i);
      double n              = random.Next(0, 100)/10.0;
      double interEventTime = -Math.Log(1.0 - n) / lambda;
      _interEventTimes.Add(interEventTime);
      _eventTime += interEventTime;
      _eventTimes.Add(_eventTime);
      Console.WriteLine(i + interEventTime + _eventTime);
    }
  }
}