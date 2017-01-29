//
// This is only a SKELETON file for the "Bob" exercise. It's been provided as a
// convenience to get you started writing code faster.
//

var Year = function(year) {
    this.year = year;
};

Year.prototype.isLeap = function() {
var by4 = this.year % 4 == 0;
var by100 = this.year %100 == 0;
var by400 = this.year % 400== 0;

return by4 && (!by100 || by100 && by400)
};

module.exports = Year;
