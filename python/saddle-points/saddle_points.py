def saddle_points(matrix):
    rows = len (matrix)
    cols = len(matrix[0]) if rows > 0 else 0

    for row in matrix:
        if cols != len(row):
            raise ValueError("irregular matrix")
        
    row_max = [max(row) for row in matrix]
    col_min = [min([matrix[r][c] for r in range(0,rows)]) for c in range(0,cols)]

    return [{"row": r+1, "column": c+1} for r in range(0,rows) for c in range(0,cols) if matrix[r][c] == row_max[r] and matrix[r][c]== col_min[c]]
