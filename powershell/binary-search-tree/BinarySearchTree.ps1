<#
.SYNOPSIS
Implement two classes, one for tree node and one for binary search tree.

.DESCRIPTION
Create a binary search tree made by many different tree node.
Each tree node instance contain the value for the node and its children if exist.
The binary search tree should have these methods:
- Insert    : take in an array of number, create node and insert them follow the property of the binary search tree.
- GetData   : return the root node that contain the entire tree's data
- Search    : take in a number to find in the binary tree, return a boolean value
- Inorder   : return an array of values in order of inorder travel
- Postorder : return an array of values in order of postorder travel
- Preorder  : return an array of values in order of preorder travel

.EXAMPLE
$tree = [BinarySearchTree]::new(@(3,4,2))

$tree.Search(3)
Return: true

$tree.Inorder()
Return: @(2, 3, 4)

$tree.PreOrder()
Return: @(3, 2, 4)

$tree.Postorder()
Return: @(2, 4, 3)
#>
Class TreeNode {
    [int]$data
    [TreeNode]$left 
    [TreeNode]$right

    TreeNode($value) {
        $this.data = $value
    }

    TreeNode([int]$value, [TreeNode]$left, [TreeNode] $right) {
        $this.data = $value
        $this.left = $left
        $this.right = $right
    }

    [string] ToString() {
        return "Node{data=$($this.data),$($this.left),$($this.right)}"
    }
}

Enum TraversalOrder {
    Pre = -1
    In = 0
    Post = 1
}


Class BinarySearchTree {
    [TreeNode]$head

    BinarySearchTree([int[]]$values) {
        #[int[]]$ordered = $values | Sort-Object
        [int[]]$ordered = $values
        #[int]$midpoint = [Math]::Floor($ordered.length / 2)
        [int]$midpoint =0
        $this.head = [TreeNode]::new($ordered[$midpoint])
        0..($ordered.length-1) | Where-Object {$_ -ne $midpoint} | ForEach-Object { $this.Insert($ordered[$_]) }
    }

    Insert([int]$value) {
        $this.Insert($value, $this.head)
    }

    Insert([int]$value, [TreeNode]$node) {
        if ($value -gt $node.data) {
            if ( $null -eq $node.right) {
                $node.right = [TreeNode]::new($value)
            }
            else {
                $this.Insert($value, $node.right)
            }
        }
        else {
            if ($null -eq $node.left) {
                $node.left = [TreeNode]::new($value)
            }
            else {
                $this.Insert($value, $node.left)
            }
        }
    }

    [TreeNode] GetData() {
        return $this.head
    }

    [bool] Search($target) {
        return $this.Search($target, $this.head)
    }

    [bool] Search([int]$target, [TreeNode]$node) {
        if ( $null -eq $node ) {
            return $false
        }
        elseif ( $node.data -eq $target) {
            return $true
        }
        elseif ($node.data -gt $target) {
            return $this.Search($target, $node.left)
        }
        else {
            return $this.Search($target, $node.right)
        }
    }

    [int[]]Visit([TraversalOrder]$order, [TreeNode]$node ) {
        [int[]]$output = @()
        if ( $null -ne $node) {
            if ( $order -eq [TraversalOrder]::Pre) {
                $output += $node.data
                $output += $this.Visit($order, $node.left)
                $output += $this.Visit( $order, $node.right)
            }
            elseif ( $order -eq [TraversalOrder]::In) {
                $output += $this.Visit($order, $node.left)
                $output += $node.data
                $output += $this.Visit($order, $node.right)
            }
            else {
                $output += $this.Visit($order, $node.left)
                $output += $this.Visit( $order, $node.right)
                $output += $node.data
            }
        }
        return $output
    }

    [int[]] Inorder() {
        return $this.Visit([TraversalOrder]::In, $this.head)
    }

    [int[]] PreOrder() {
        return $this.Visit([TraversalOrder]::Pre, $this.head)
    }

    [int[]] PostOrder() {
        return $this.Visit([TraversalOrder]::Post, $this.head)
    }

    [string] ToString() {
        <#
        .DESCRIPTION
        Tostring method to help print out the tree in a nice format for viewing
        Adapt from : https://stackoverflow.com/questions/4965335/how-to-print-binary-tree-diagram-in-java
        #>
        $textBuilder = [System.Text.StringBuilder]::new()
        $this.PrintBinaryTree($textBuilder, "", "", $this.root)
        return $textBuilder.ToString()
    }

    hidden [void] PrintBinaryTree ([System.Text.StringBuilder]$string, [string]$prefix, [string]$childrenPrefix, [TreeNode]$root) {
        $string.Append("$prefix$($root.data)`n")

        if ($root.left -and $root.right) {
            #draw left child
            $this.PrintBinaryTree($string, ($childrenPrefix + "├──L:"), ($childrenPrefix + "│   "), $root.left)
        }
        elseif ($root.left) {
            $this.PrintBinaryTree($string, ($childrenPrefix + "└──L:"), ($childrenPrefix + "    "), $root.left)
        }
        
        if ($root.right) {
            #draw right child
            $this.PrintBinaryTree($string, ($childrenPrefix + "└──R:"), ($childrenPrefix + "    "), $root.right)
        }
    }

}