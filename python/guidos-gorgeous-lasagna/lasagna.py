EXPECTED_BAKE_TIME = 40
PREPARATION_TIME = 2

def bake_time_remaining(elapsed_bake_time):
    """Calculate the bake time remaining.

    :param elapsed_bake_time: int baking time already elapsed.
    :return: int remaining bake time derived from 'EXPECTED_BAKE_TIME'.

    Function that takes the actual minutes the lasagna has been in the oven as
    an argument and returns how many minutes the lasagna still needs to bake
    based on the `EXPECTED_BAKE_TIME`.
    """
    return EXPECTED_BAKE_TIME - elapsed_bake_time

def preparation_time_in_minutes(layers):
    """Calculate the time required to perpare the specified number of layers

    :param layers: int number of layers to prepare
    :return: int the total time spent preparing the lasagna

    Function that estimates the time spent in preparation based upon the size of the lasagana    
    """
    return layers * PREPARATION_TIME

def elapsed_time_in_minutes(layers, elapsed_bake_time):
    """calculate the time spent thus far baking the lasagna

    :param layers: int the number of layers in the lasagana
    :param elapsed_bake_time: int the time spent baking thus far
    :return: int the total time spent preparing and baking the lasagna


    """
    return preparation_time_in_minutes(layers) + elapsed_bake_time
