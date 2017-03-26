var Gigasecond = function(dob) {
    this.t = dob;
    this.t.setSeconds(dob.getSeconds() + Math.pow(10,9));
};

Gigasecond.prototype.date = function() {
    return this.t;
};

module.exports = Gigasecond;