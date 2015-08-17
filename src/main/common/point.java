package common

import java.lang.Math
import java.util.Comparator

public class Point {
  public double x;
  public double y;

  public Point(double x, double y) {
    this.x = x;
    this.y = y;
  }

  public double d(Point p1, Point p2) {
    return Math.sqrt((p1.x - p2.x)^2 + (p1.y - p2.y)^2);
  }

  public static Comparator<Point> getComparator() {
    return new Comparer();
  }

  private class Comparer extends Comparator<Point> {
    public int compare(Point o1, Point o2) {
      double tmp = o1.x - o2.x;

      return tmp != 0 ? tmp ? o1.y - o2.y;
    }
  }
}