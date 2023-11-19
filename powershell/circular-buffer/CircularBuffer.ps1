<#
.SYNOPSIS
Implement the circular buffer data structure.

.DESCRIPTION
A circular buffer, cyclic buffer or ring buffer is a data structure that uses a single, fixed-size buffer as if it were connected end-to-end.
Please implement the circular buffer class with these methods:
- Write     : write new value into the buffer, raise error if the buffer is full.
- Overwrite : overwrite the oldest element in the buffer if the buffer is full, otherwise behave like write.
- Clear     : clear all elements in the buffer, it is now empty.
- Read      : read the oldest element in the buffer, and return its value.

.EXAMPLE
$buffer = [CircularBuffer]::new(2)

$buffer.Write(1)
$buffer.Read()
Return: 1

$buffer.Write(2)
$buffer.Write(3)
$buffer.Overwrite(5)
$buffer.Read()
Return: 5

$buffer.Clear()
$buffer.Read()
Throw "BufferError: Circular buffer is empty"
#>

Class CircularBuffer {
    [object[]]$buffer
    [int]$size
    [int]$current = 0
    [int]$oldest = 0

    CircularBuffer([int]$size) {
        $this.size = $size
        $this.Clear()
    }

    Write([int]$value) {
        $starting = $this.current
        $search = $this.current
        $index = $null

        do {
            if ($null -eq $this.buffer[$search] ){
                $index = $search
            }
            $search = ($search + 1)% $this.size
        } while ($null -eq $index -and $search -ne $starting)

        if( $null -eq $index){
            throw "BufferError: Circular buffer is full"
        }else {
            $this.buffer[$index] = $value
            $this.current = ($index + 1) % $this.size
        }
    }

    Overwrite([int]$value) {
        try {
            $this.Write($value)
        }
        catch {
            $this.buffer[$this.oldest] = $value
            $this.oldest = ($this.oldest + 1) % $this.size
        }
    }

    Clear() {
        $this.buffer = new-object 'object[]' $this.size
        for ($i = 0; $i -lt $this.size; $i++) {
            $this.buffer[$i] = $Null
        }
        $this.oldest = 0
        $this.current = 0
    }

    [int] Read() {
        $value = $this.buffer[$this.oldest]
        if ( $null -eq $value) {
            throw "BufferError: Circular buffer is empty"
        }
        $this.buffer[$this.oldest] = $null
        $this.oldest = ($this.oldest + 1) % $this.size

        return $value
        
    }
}

