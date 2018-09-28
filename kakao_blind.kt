data class Point(val x:Int, val y:Int, val value:Int)
data class TreeNode(var left:TreeNode?, var right:TreeNode?, val point:Point)
class Solution {
    fun solution(nodeinfo: Array<IntArray>): Array<IntArray> {
        val list = ArrayList<Point>()
        var i = 1
        for(y in nodeinfo)
            list.add(Point(y[0], y[1], i++))
        var ret = list.sortedWith(compareByDescending<Point> {it.y }.thenBy{ it.x })
        val root = TreeNode(null, null, ret[0])
        for(temp in ret.subList(1, ret.count()))
            addTreeNode(temp, root)
        val preOrderRet = ArrayList<Int>()
        val postOrderRet = ArrayList<Int>()
        preOrder(preOrderRet, root)
        postOrder(postOrderRet, root)
        return arrayOf(preOrderRet.toIntArray(), postOrderRet.toIntArray())
    }
    private fun addTreeNode(target:Point, root:TreeNode){
        if(root.point.x > target.x){
            root.left?.let { addTreeNode(target, it) }
                    ?:let { root.left = TreeNode(null, null, target) }
        }else{
            root.right?.let { addTreeNode(target, it) }
                    ?:let { root.right = TreeNode(null,null, target) }
        }
    }
    private fun preOrder(ret:ArrayList<Int>, root:TreeNode){
        ret.add(root.point.value)
        root.left?.let{preOrder(ret, root.left!!)}
        root.right?.let{preOrder(ret, root.right!!)}
    }
    private fun postOrder(ret:ArrayList<Int>, root:TreeNode){
        root.left?.let { postOrder(ret, root.left!!) }
        root.right?.let { postOrder(ret, root.right!!) }
        ret.add(root.point.value)
    }
}

fun main(args : Array<String>) {

    var ret = ArrayList<IntArray>()
    ret.add(intArrayOf(5,3))
    ret.add(intArrayOf(11,5))
    ret.add(intArrayOf(13,3))
    ret.add(intArrayOf(3,5))
    ret.add(intArrayOf(6,1))
    ret.add(intArrayOf(1,3))
    ret.add(intArrayOf(8,6))
    ret.add(intArrayOf(7,2))
    ret.add(intArrayOf(2,2))
    Solution().solution(ret.toTypedArray())
}
