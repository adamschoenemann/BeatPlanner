//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.core;



public class Meter   
{
    private int upper;
    private int lower;
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
            return String.format("%d/%d}", getUpper(), getLower());
        }
        catch (RuntimeException e) {
            throw e;
        }
    
    }

    public static final Meter Common = new Meter(4,4);

    public int getUpper() {
        return upper;
    }

    public int getLower() {
        return lower;
    }

    public void setUpper(int upper) {
        this.upper = upper;
    }

    public void setLower(int lower) {
        this.lower = lower;
    }
}


