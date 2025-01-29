## Job
character-job-requirement = Вы должны{$inverted ->
    [true]{" "}не
    *[other]{""}
} иметь должность: {$jobs}

character-department-requirement = Вы должны{$inverted ->
    [true]{" "}не
    *[other]{""}
} быть в отделе: {$departments}

character-timer-department-insufficient = Нужно [color=yellow]{TOSTRING($time, "0")}[/color] [color={$departmentColor}]{$department}[/color]
character-timer-department-too-high = Нужно [color=yellow]{TOSTRING($time, "0")}[/color] [color={$departmentColor}]{$department}[/color]

character-timer-overall-insufficient = Нужно [color=yellow]{TOSTRING($time, "0")}[/color]
character-timer-overall-too-high = Нужно [color=yellow]{TOSTRING($time, "0")}[/color]

character-timer-role-insufficient = You require [color=yellow]{TOSTRING($time, "0")}[/color] more minutes with [color={$departmentColor}]{$job}[/color]
character-timer-role-too-high = You require[color=yellow] {TOSTRING($time, "0")}[/color] fewer minutes with [color={$departmentColor}]{$job}[/color]


## Logic
character-logic-and-requirement-listprefix = {""}
    {$indent}[color=gray]&[/color]{" "}
character-logic-and-requirement = Вы должны{$inverted ->
    [true]{" "}не
    *[other]{""}
} удовлетворять [color=red]этим[/color] [color=gray]условиям[/color]: {$options}

character-logic-or-requirement-listprefix = {""}
    {$indent}[color=white]O[/color]{" "}
character-logic-or-requirement = Вы должны{$inverted ->
    [true]{" "} не
    *[other]{""}
} подходить [color=red]минимум по 1 из этих[/color][color=white]условий[/color]: {$options}

character-logic-xor-requirement-listprefix = {""}
    {$indent}[color=white]X[/color]{" "}
character-logic-xor-requirement = Вы должны{$inverted ->
    [true]{" "}не
    *[other]{""}
} подходить [color=red]только[/color] [color=white]1 условию[/color]: {$options}


## Profile
character-age-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be within [color=yellow]{$min}[/color] and [color=yellow]{$max}[/color] years old

character-backpack-type-requirement = Вы должны {$inverted ->
    [true] не использовать
    *[other] использовать
}  [color=brown]{$type}[/color] в качестве сумки

character-clothing-preference-requirement = Вы должны {$inverted ->
    [true] не надевать
    *[other] надеть
} [color=white]{$type}[/color]

character-gender-requirement = Вы должны {$inverted ->
    [true] не иметь
    *[other] иметь
} местоимение [color=white]{$gender}[/color]

character-sex-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be [color=white]{$sex ->
    [None] unsexed
    *[other] {$sex}
}[/color]
character-species-requirement = Вы должны{$inverted ->
    [true]{" "}не
    *[other]{""}
} быть {$species}

character-height-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be {$min ->
    [-2147483648]{$max ->
        [2147483648]{""}
        *[other] shorter than [color={$color}]{$max}[/color]cm
    }
    *[other]{$max ->
        [2147483648] taller than [color={$color}]{$min}[/color]cm
        *[other] between [color={$color}]{$min}[/color] and [color={$color}]{$max}[/color]cm tall
    }
}

character-width-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be {$min ->
    [-2147483648]{$max ->
        [2147483648]{""}
        *[other] skinnier than [color={$color}]{$max}[/color]cm
    }
    *[other]{$max ->
        [2147483648] wider than [color={$color}]{$min}[/color]cm
        *[other] between [color={$color}]{$min}[/color] and [color={$color}]{$max}[/color]cm wide
    }
}

character-weight-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be {$min ->
    [-2147483648]{$max ->
        [2147483648]{""}
        *[other] lighter than [color={$color}]{$max}[/color]kg
    }
    *[other]{$max ->
        [2147483648] heavier than [color={$color}]{$min}[/color]kg
        *[other] between [color={$color}]{$min}[/color] and [color={$color}]{$max}[/color]kg
    }
}


character-trait-requirement = Вы должны {$inverted ->
    [true] не иметь
    *[other] иметь
} один из перков: {$traits}

character-loadout-requirement = Вы должны {$inverted ->
    [true] не иметь
    *[other] иметь
} один из этих лодаутов: {$loadouts}


character-item-group-requirement = Вы должны {$inverted ->
    [true] иметь {$max} или больше
    *[other] иметь {$max} или меньше
} предметов из этой группы [color=white]{$group}[/color]


## Whitelist
character-whitelist-requirement = You must{$inverted ->
    [true]{" "}not
    *[other]{""}
} be whitelisted

## CVar

character-cvar-requirement =
    The server must{$inverted ->
    [true]{" "}not
    *[other]{""}
} have [color={$color}]{$cvar}[/color] set to [color={$color}]{$value}[/color].
