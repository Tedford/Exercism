"""exercise"""


def get_coordinate(record):
    """

    :param record: tuple - a (treasure, coordinate) pair.
    :return: str - the extracted map coordinate.
    """

    return record[1]


def convert_coordinate(coordinate):
    """

    :param coordinate: str - a string map coordinate
    :return:  tuple - the string coordinate seperated into its individual components.
    """

    return tuple(coordinate)


def compare_records(azara_record, rui_record):
    """

    :param azara_record: tuple - a (treasure, coordinate) pair.
    :param rui_record: tuple - a (location, coordinate, quadrant) trio.
    :return: bool - True if coordinates match, False otherwise.
    """
    rui_coordinate = rui_record[1][0] + rui_record[1][1]
    return azara_record[1] == rui_coordinate


def create_record(azara_record, rui_record):
    """

    :param azara_record: tuple - a (treasure, coordinate) pair.
    :param rui_record: tuple - a (location, coordinate, quadrant) trio.
    :return:  tuple - combined record, or "not a match" if the records are incompatible.
    """

    return azara_record + rui_record if compare_records(azara_record, rui_record) else "not a match"


def clean_up(combined_record_group):
    """

    :param combined_record_group: tuple of tuples - everything from both participants.
    :return: string of tuples separated by newlines - everything "cleaned". Excess coordinates and information removed.
    """
    return '\n'.join(print_report(record) for _, record in enumerate(combined_record_group)) + '\n'


def print_report(record):
    """
    :param record: the combined tuple data
    :return: the formatted string
    """
    azara_location, _, rui_location, rui_coordinate, quadrant = tuple(record)
    return f'({quote(azara_location)}, {quote(rui_location)}, ({quote(rui_coordinate[0])}, {quote(rui_coordinate[1])}), {quote(quadrant)})'


def quote(text):
    """
    :param s: the string value to enquote
    :return: the enquoted string value
    """

    return f'"{text}"' if text.find("'") != -1 else f'\'{text}\''
