export function getLocalStoredValue(key: string): string {
    return window.localStorage[key];
};
export function setLocalStoredValue(key: string, value: string) {
    window.localStorage[key] = value;
};