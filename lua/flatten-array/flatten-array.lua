local function flatten(input)
    local result = {}

    for i, value in ipairs(input) do
        if value == tonumber(value) then
            table.insert(result, value)
        else
            for _, v2 in ipairs(flatten(value)) do
                table.insert(result, v2)
            end
        end
    end

    return result
end

return flatten
