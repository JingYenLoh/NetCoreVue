// @ts-check

export const alphaNumSpaces = {
  getMessage: () => 'Name may only contain alphabets, numbers and spaces.',
  validate: value => /^[a-z A-Z0-9.]*$/.test(value)
}
