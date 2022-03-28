def add_win(record):
    wins, losses, draws, points = record
    return (wins+1, losses, draws, points +3)

def add_loss(record):
    wins, losses, draws, points = record
    return (wins, losses+1, draws, points)

def add_draw(record):
    wins, losses, draws, points = record
    return (wins, losses, draws+1, points+1)

def format(name, record):
    (wins, draws, losses, points) = record
    formatted =f'{name:<31}|{wins+draws+losses:3} |{wins:3} |{losses:3} |{draws:3} |{points:3}' 
    print(formatted)
    return formatted

def tally(rows):
    scores = dict()
    for row in rows:
        parts= row.split(';')
        t1 = parts[0]
        t2 = parts[1]
        r = parts[2]
        if t1 not in scores:
            t1_tally = (0,0,0,0)
            scores[t1] = t1_tally
        else:
            t1_tally = scores[t1]

        if t2 not in scores:
            t2_tally = (0,0,0,0)
            scores[t2] = t2_tally
        else:
            t2_tally = scores[t2]

        if r == 'win':
            scores[t1] = add_win(t1_tally)
            scores[t2] = add_loss(t2_tally)
        elif r == 'loss':
            scores[t1] = add_loss(t1_tally)
            scores[t2] = add_win(t2_tally)
        else:
            scores[t1] = add_draw(t1_tally)
            scores[t2] = add_draw(t2_tally)

    results = [(team, record) for team,record in scores.items()]
    results.sort(key= lambda k: (-k[1][3], k[0]), reverse=True)
    results = [format(team, record) for team,record in results]
    results.append("Team                           | MP |  W |  D |  L |  P")
    results.reverse()
    return results