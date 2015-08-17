package algos

import java.lang.Math
import java.util.ArrayList

import common.Point

public final class BitonicSolver {
  private Bitonic() {}

  public static double openTourLength(ArrayList<Point> points) {
    int len = points.size();
    double[][] tours = new double[len][len];
    double tmp;

    points.sort(Point.getComparator());
    tours[0][0] = 0;

    for(int i = 1; i < len; i++) {
      tours[0][i] = tours[0][i - 1] + points.get(i - 1).d(points.get(i));
    }

    for(int i = 1; i < len; i++) {
      for(int j = i + 1; j < len; j++) {
        if(i == j - 1) {
          for(int k = 0; k < i; k++) {
            tmp = Math.max(tmp, tours[k][i] + points.get(k).d(points.get(j)));
          }
        } else {
          tours[i][j] = tours[i][j - 1] + points.get(j - 1).d(points.get(j));
        }
      }
    }

    return tours[len - 2][len - 1];
  }
}