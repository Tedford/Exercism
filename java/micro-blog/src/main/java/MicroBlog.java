class MicroBlog {
    public String truncate(String input) {
        var sb = new StringBuilder();
         input.codePoints().limit(5).forEach(x-> sb.append(Character.toChars(x)));
        return sb.toString();
    }
}
