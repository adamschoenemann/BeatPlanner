//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.core;



public class Meter   
{
    public int upper;
    public int lower;
    public Meter(int u, int l) {
        upper = u;
        if (l == 2 || l == 4 || l == 8 || l == 16 || l == 32)
            lower = l;
        else
            throw new IllegalArgumentException("Invalid lower meter given");
    }

    @Override
    public String toString() {
        try
        {
            return String.format("%d/%d}", upper, lower);
        }
        catch (RuntimeException e) {
            throw e;
        }
    
    }

    public static final Meter Common = new Meter(4,4);
}


