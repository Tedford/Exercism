local all_your_base = {}

all_your_base.convert = function(from_digits, from_base)
    assert(from_base > 1, "invalid input base")
    local result = 0
    local exponent = 0

    for i = #from_digits, 1, -1 do
        assert(from_digits[i] > -1, "negative digits are not allowed")
        assert(from_digits[i] < from_base, "digit out of range")

        result = result + (from_digits[i] * from_base ^ exponent)
        exponent = exponent + 1
    end

    return {
        to = function(to_base)
            assert(to_base > 1, "invalid output base")

            local output = {}
            if result == 0 then
                table.insert(output, 0)
            else
                local remainder = result

                while remainder > 0 do
                    local digit = remainder % to_base
                    remainder = remainder // to_base
                    table.insert(output, 1, digit)
                end
            end

            return output
        end
    }
end

return all_your_base
