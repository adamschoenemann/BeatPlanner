//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.core;



public class Meter   
{
    public int Upper;
    public int Lower;
    public Meter(int u, int l) {
        Upper = u;
        if (l == 2 || l == 4 || l == 8 || l == 16 || l == 32)
            Lower = l;
        else
            throw new IllegalArgumentException("Invalid lower meter given");
    }

    public String toString() {
        try
        {
            return String.format("%d/%d}", Upper, Lower);
        }
        catch (RuntimeException e) {
            throw e;
        }
    
    }

    public static final Meter Common = new Meter(4,4);
}


