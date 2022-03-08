export function getLocalStoredValue(key) {
    return window.localStorage[key];
}
;
export function setLocalStoredValue(key, value) {
    window.localStorage[key] = value;
}
;
