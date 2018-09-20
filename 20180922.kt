import java.lang.NullPointerException
import java.util.*
import kotlin.math.absoluteValue


//2018-09-20,    Asteroid Collision
/*
class Solution {
    fun asteroidCollision(asteroids: IntArray): IntArray {
        val q = LinkedList<Int>()
        for(asteroid in asteroids){
            if(asteroid >= 0)
                q.offer(asteroid)
            else
            {
                while(q.isNotEmpty() && q.peekLast() > 0 && q.peekLast().absoluteValue < asteroid.absoluteValue )
                    q.pollLast()
                if(q.isNotEmpty() && (q.peekLast() + asteroid) == 0){
                    q.pollLast()
                    continue
                }
                if(q.isEmpty() || (q.isNotEmpty() && q.peekLast() <0))
                    q.offer(asteroid)
            }
        }
        return q.toIntArray()
    }
}*/
//2018-09-20,    Top K Frequent Elements
/*
class Solution {
    fun topKFrequent(nums: IntArray, k: Int): List<Int> {
        return hashMapOf<Int,Int>().let {
            for (num in nums){
                if(it.containsKey(num))
                    it[num] = it[num]!! +1
                else
                    it[num] = 1
            }
            it.entries.sortedByDescending{ x->x.value } .map { x->x.key }.subList(0,k)
        }
    }
}
*/
//2018-09-20,     Unique Paths II
class Solution {
    val INITIAL = -1
    val MAX = 101
    val visited = Array(101){BooleanArray(101)}
    val cached = Array(101){IntArray(101)}
    var arr:Array<IntArray>? = null
    val sx = intArrayOf(1,0)
    val sy = intArrayOf(0,1)
    fun uniquePathsWithObstacles(obstacleGrid: Array<IntArray>): Int {
        for(i in 0..MAX-1)
            for(j in 0..MAX-1)
                cached[i][j] = INITIAL
        arr = obstacleGrid
        return dfs(0,0)
    }
    fun dfs(y :Int, x:Int) :Int{
        try {
            if(arr!![y][x] == 1)
                return 0
            if(y == arr!!.size-1 && x == arr!![0].size-1)
                return 1
            if(cached[y][x] != -1)
                return cached[y][x]
            var ret = 0
            visited[y][x] = true
            for(i in 0..1){
                val ny = y + sy[i]
                val nx = x + sx[i]
                if(ny >= arr!!.size || nx >= arr!![0].size )
                    continue
               if(!visited[ny][nx])
                   ret += dfs(ny, nx)
            }
            cached[y][x] = ret
            return ret
        }finally {
            visited[y][x] = false
        }
    }
}
fun main(args:Array<String>){


}

