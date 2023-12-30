return {
  encode = function(s)
    local current = string.sub(s, 1, 1)
    local count = 1
    local encoded = ""
    for i = 2, string.len(s) do
      local c = string.sub(s, i, i)
      if c == current then
        count = count + 1
      else
        if count == 1 then
          encoded = string.format("%s%s", encoded, current)
        else
          encoded = string.format("%s%d%s", encoded, count, current)
        end
        count = 1
        current = c
      end
    end

    if count == 1 then
      encoded = string.format("%s%s", encoded, current)
    else
      encoded = string.format("%s%d%s", encoded, count, current)
    end

    return encoded
  end,

  decode = function(s)
    local decoded = ""
    local index = 1

    while index <= string.len(s) do
      local current = string.sub(s, index, index)
      local number = tonumber(current)
      if number ~= nil then
        local j = 0
        while tonumber(string.sub(s, index + j + 1, index + j + 1)) ~= nil do
          j = j + 1
        end
        number = tonumber(string.sub(s, index, index + j))
        current = string.sub(s, index + j + 1, index + j + 1)
        decoded = string.format("%s%s", decoded, string.rep(current, number - 1))
        index = index + j + 1
      else
        decoded = string.format("%s%s", decoded, current)
        index = index + 1
      end
    end
    return decoded
  end
}
