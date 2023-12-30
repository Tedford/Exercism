return function(pos)
    assert(-1 < pos.row and pos.row < 8)
    assert(-1 < pos.column and pos.column < 8)

    return {
        pos = pos,
        can_attack = function(other)
            return pos.row == other.pos.row or pos.column == other.pos.column or
            math.abs(pos.column - other.pos.column) == math.abs(pos.row - other.pos.row)
        end
    }
end