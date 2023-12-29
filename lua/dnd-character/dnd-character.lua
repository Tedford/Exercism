local Character = {}

local function roll_dice()
  local rolls = {}
  for i = 1,4  do
    rolls[i]  = math.random(1,6)
  end
  return rolls
end

local function ability(scores)
  if scores == nil then
    scores = roll_dice()
  end

  table.sort(scores)

  local sum = 0
  for i = 2, 4 do
    sum = sum + scores[i]
  end

  return sum
end

local function modifier(input)
  local mod = 0
  if input > 17 then
    mod = 4
  elseif input > 15 then
    mod = 3
  elseif input > 13 then
    mod = 2
  elseif input > 11 then
    mod = 1
  elseif input > 9 then
    mod = 0
  elseif input > 7 then
    mod = -1
  elseif input > 5 then
    mod = -2
  elseif input > 3 then
    mod = -3
  else
    mod = -4
  end

  return mod
end

function Character:new(name)
  local con = ability(nil)
  local c = {
    name = name,
    strength = ability(nil),
    dexterity = ability(nil),
    constitution = con,
    intelligence = ability(nil),
    wisdom = ability(nil),
    charisma = ability(nil),
    hitpoints = 10 + modifier(con)
  }
  return c
end

return {
  Character = Character,
  ability = ability,
  roll_dice = roll_dice,
  modifier = modifier
}
