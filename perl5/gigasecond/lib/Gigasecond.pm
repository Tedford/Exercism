package Gigasecond;

use v5.38;

use Exporter qw<import>;
use Time::Seconds;
use Time::Piece;

our @EXPORT_OK = qw<add_gigasecond>;

sub add_gigasecond ($time) {
    #1977-06-13
    my $fmt = "%Y-%m-%dT%H:%M:%S";
    my $t = Time::Piece->strptime($time,$fmt);
    $t += Time::Seconds->new(10**9);
    #"2009-02-19T01:46:40"
    return $t->strftime($fmt);
}

