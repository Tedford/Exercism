"""exercise"""


def spiral_matrix(size):
    """
    :param size:
    :return:
    """

    # construct
    matrix = [0 for _ in range(0, size)]
    for index, _ in enumerate(matrix):
        matrix[index] = [0 for _ in range(0, size)]

    extents = [-1, 0, size-1, size-1]
    direction = 'r'
    x = y = 0
    for i in range(1, size*size+1):
        matrix[y][x] = i

        if direction == 'r':
            if x < extents[2]:
                x += 1
            else:
                direction = 'd'
                y += 1
                extents[2] = x-1
        elif direction == 'd':
            if y < extents[3]:
                y += 1
            else:
                direction = 'l'
                extents[3] = y-1
                x -= 1
        elif direction == 'l':
            if x-1 > extents[0]:
                x-= 1
            else:
                direction = 'u'
                extents[0] = x
                y-=1
        elif direction == 'u':
            if y-1 > extents[1]:
                y-= 1
            else:
                direction = 'r'
                extents[1] = y
                x+=1

    return matrix
